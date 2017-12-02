public enum EnginePacketType
{
	UNKNOWN = -1,
	OPEN = 0,
	CLOSE = 1,
	PING = 2,
	PONG = 3,
	MESSAGE = 4,
	UPGRADE = 5,
	NOOP = 6
}


public enum SocketPacketType
{
	UNKNOWN = -1,
	CONNECT = 0,
	DISCONNECT = 1,
	EVENT = 2,
	ACK = 3,
	ERROR = 4,
	BINARY_EVENT = 5,
	BINARY_ACK = 6,
	CONTROL = 7
}

public class Packet
{
	public EnginePacketType enginePacketType;
	public SocketPacketType socketPacketType;

	public int attachments;
	public string nsp;
	public int id;
	public JSONObject json;

	public Packet() : this(EnginePacketType.UNKNOWN, SocketPacketType.UNKNOWN, -1, "/", -1, null) { }
	Packet(EnginePacketType enginePacketType) : this(enginePacketType, SocketPacketType.UNKNOWN, -1, "/", -1, null) { }

	Packet(EnginePacketType enginePacketType, SocketPacketType socketPacketType, int attachments, string nsp, int id, JSONObject json)
	{
		this.enginePacketType = enginePacketType;
		this.socketPacketType = socketPacketType;
		this.attachments = attachments;
		this.nsp = nsp;
		this.id = id;
		this.json = json;
	}

	public Packet(string eventName, JSONObject data)
	{
		this.enginePacketType = EnginePacketType.MESSAGE;
		this.socketPacketType = SocketPacketType.EVENT;
		this.attachments = 0;
		this.nsp = "/";
		this.id = -1;
		this.json = new JSONObject(string.Format("[\"{0}\",{1}]", eventName, data));
	}

	public override string ToString()
	{
		return string.Format("[Packet: enginePacketType={0}, socketPacketType={1}, attachments={2}, nsp={3}, id={4}, json={5}]", enginePacketType, socketPacketType, attachments, nsp, id, json);
	}
}
