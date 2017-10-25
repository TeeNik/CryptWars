using System;
using System.Collections;
using System.Text;
using UnityEngine;

public class Decoder
{
	public Packet Decode(string data)
	{
			//#if SOCKET_IO_DEBUG
			//Debug.Log("[SocketIO] Decoding: " + data);
			//#endif

			//string data = e.Data;
			Packet packet = new Packet();
			int offset = 0;

			// look up packet type
			int enginePacketType = int.Parse(data.Substring(offset, 1));
			packet.enginePacketType = (EnginePacketType)enginePacketType;

			if (enginePacketType == (int)EnginePacketType.MESSAGE) {
				int socketPacketType = int.Parse(data.Substring(++offset, 1));
				packet.socketPacketType = (SocketPacketType)socketPacketType;
			}

			// connect message properly parsed
			if (data.Length <= 2) {
				//#if SOCKET_IO_DEBUG
				//Debug.Log("[SocketIO] Decoded: " + packet);
				//#endif
				return packet;
			}

			// look up namespace (if any)
			if ('/' == data [offset + 1]) {
				StringBuilder builder = new StringBuilder();
				while (offset < data.Length - 1 && data[++offset] != ',') {
					builder.Append(data [offset]);
				}
				packet.nsp = builder.ToString();
			} else {
				packet.nsp = "/";
			}

			// look up id
			char next = data [offset + 1];
			if (next != ' ' && char.IsNumber(next)) {
				StringBuilder builder = new StringBuilder();
				while (offset < data.Length - 1) {
					char c = data [++offset];
					if (char.IsNumber(c)) {
						builder.Append(c);
					} else {
						--offset;
						break;
					}
				}
				packet.id = int.Parse(builder.ToString());
			}

			// look up json data
			if (++offset < data.Length - 1) {
				try {
					//#if SOCKET_IO_DEBUG
					//Debug.Log("[SocketIO] Parsing JSON: " + data.Substring(offset));
					//#endif
					packet.json = new JSONObject(data.Substring(offset));
				} catch (Exception ex) {
					Debug.LogException(ex);
				}
			}

			//#if SOCKET_IO_DEBUG
			//Debug.Log("[SocketIO] Decoded: " + packet);
			//#endif

			return packet;
	}

	public SocketIOEvent Parse(JSONObject json)
	{
		if (json.Count < 1 || json.Count > 2)
		{
			Debug.LogWarning("SocketIOException: Invalid number of parameters received: " + json.Count);
			return new SocketIOEvent("error");
		}

		if (json[0].type != JSONObject.Type.STRING)
		{
			Debug.LogWarning("SocketIOException: Invalid parameter type. " + json[0].type + " received while expecting " + JSONObject.Type.STRING);
			return new SocketIOEvent("error");
		}

		if (json.Count == 1)
		{
			return new SocketIOEvent(json[0].str);
		}

		if (json[1].type != JSONObject.Type.OBJECT)
		{
			Debug.LogWarning("SocketIOException: Invalid argument type. " + json[1].type + " received while expecting " + JSONObject.Type.OBJECT);
			return new SocketIOEvent("error");
		}

		return new SocketIOEvent(json[0].str, json[1]);
	}
}
