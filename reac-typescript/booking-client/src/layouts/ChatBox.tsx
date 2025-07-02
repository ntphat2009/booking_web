import { useEffect, useState, React } from 'react';
import Connector from "./signalR-connection"
interface ChatBoxProps {
  toEmail: string;
}
interface ReceiveMessage {
  from: string;
  message: string;
}
const ChatBox: React.FC = ({ toEmail }: ChatBoxProps) => {
  const connector = Connector();
  const [messages, setMessages] = useState<ReceiveMessage[]>([]);
  const [inputMessage, setInputMessage] = useState<string>('');
  const sendMessage = async () => {
    if (inputMessage.trim() !== "") {
      try {
        await connector.sendMessageToUser(toEmail, inputMessage);
        connector.events((from,message) => {
          console.log(`Tin nhắn từ ${message}`);
          setMessages((prev) => [...prev, { from, message }]);
        });
        setInputMessage("");
      } catch (error) {
        console.error("Lỗi khi gửi tin nhắn:", error);
      }
    }
  };
  return (
    <div className="chatbox-container">
      <div className="chatbox-header">
        <h3>Chat</h3>
      </div>
      <div className="chatbox-messages">
          {messages.length > 0 ? messages.map((msg) => (msg.from !== toEmail ?
            (
              <div className=" container-message text-start">
                <p className="fs-8"> {msg.from}</p>

                <span className="message received">
                {msg.message}
                </span>
              </div>
            )
            : (
              <div className="container-message text-end">
                <span className="message sent">
                {msg.message}
                </span>
              </div>
            ))) : ("")}
      </div>
      <div>
      </div>
      <div className="chatbox-input">
      </div>
      <input
        type="text"
        placeholder="Type your message"
        value={inputMessage}
        onChange={(e) => setInputMessage(e.target.value)}
      />
      <button className="float-end" onClick={sendMessage}><i className="fas fa-paper-plane fa-rotate-by" style={{}}></i></button>
    </div>
  );
};

export default ChatBox;