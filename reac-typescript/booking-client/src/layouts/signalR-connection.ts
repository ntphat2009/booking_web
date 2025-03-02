import * as signalR from "@microsoft/signalr";
// const URL = process.env.HUB_ADDRESS ?? "https://localhost:7214/chatHub"; //or whatever your backend port is
class Connector {
    private connection: signalR.HubConnection;
    public events: (onMessageReceived: (username: string, message: string) => void) => void;
    static instance: Connector;
    constructor() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7214/chatHub")
            .withAutomaticReconnect()
            .build();
        this.connection.start().catch(err => console.error("error when start connected",err));
        this.events = (onMessageReceived) => {
            this.connection.on("receiveMessenger", (username, message) => {
                onMessageReceived(username, message);
            });
        };
    }
    public newMessage = (messages: string) => {
        this.connection.send("newMessage", "foo", messages).then(x => console.log("sent",messages));
    }
    public static getInstance(): Connector {
        if (!Connector.instance)
            Connector.instance = new Connector();
        return Connector.instance;
    }
}

export default Connector.getInstance;