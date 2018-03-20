package fly;

public class Fly {
	private int id;
	private int timeStamp;
		
	public Fly(int id, int timeStamp) {
		super();
		this.id = id;
		this.timeStamp = timeStamp;
	}
	@Override
	public String toString() {
		return "Plane "+ id;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public int getTimeStamp() {
		return timeStamp;
	}
	public void setTimeStamp(int timeStamp) {
		this.timeStamp = timeStamp;
	}
	
}
