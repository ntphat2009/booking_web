import * as signalR from "@microsoft/signalr";

// const URL = process.env.HUB_ADDRESS ?? "https://localhost:7214/chatHub"; //or whatever your backend port is
class Connector {
    private connection: signalR.HubConnection;
    public events: (onMessageReceivedByUser: (from: string, message: string) => void) => void;
    static instance: Connector;
    constructor() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7214/chatHub", {
                accessTokenFactory: () => sessionStorage.getItem("token") || "",
            })
            .withAutomaticReconnect()
            .build();

        this.connection.start().catch(err => console.error("error when start connected", err));
        this.events = (onMessageReceivedByUser) => {
            this.connection.on("ReceiveMessageFromUser", (from, message) => {
                onMessageReceivedByUser(from, message);
                console.log("Tinnhan tu constructor",message)
            });
        };
    }
    public sendMessageToUser = async (toEmail: string, messages: string) => {
        await this.connection.send("SendMessageToUser", toEmail, messages)
    }
    public sendMessageToCaller = async (toEmail: string, messages: string) => {
        await this.connection.invoke("SendMessageToCaller", toEmail, messages)
    }
    public sendMessageToAll = async (toEmail: string, messages: string) => {
        await this.connection.invoke("SendMessage", toEmail, messages)
    }
    public static getInstance(): Connector {
        if (!Connector.instance)
            Connector.instance = new Connector();
        return Connector.instance;
    }
}

export default Connector.getInstance;