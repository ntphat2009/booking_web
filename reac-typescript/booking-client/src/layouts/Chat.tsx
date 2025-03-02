// ChatComponent.tsx
import React, { useEffect, useState } from 'react';
import connector from '../layouts/signalR-connection'; // đường dẫn đến file Connector.ts

interface ChatMessage {
  username: string;
  message: string;
}

const ChatComponent: React.FC = () => {
  const [messages, setMessages] = useState<ChatMessage[]>([]);
  const [inputMessage, setInputMessage] = useState<string>('');
  const [username, setUsername] = useState<string>('John Doe');

  useEffect(() => {
    // Đăng ký sự kiện nhận tin nhắn từ server
    connector().events((username: string, message: string) => {
      setMessages((prev) => [...prev, { username: username, message: message }]);
    });
  }, []);

  const handleSendMessage = () => {
    // Gửi tin nhắn qua Connector
    console.log("input",inputMessage)
    connector().newMessage(inputMessage);
    setInputMessage('');
  };

  return (
    <div>
      <h2>Chat App</h2>
      <div>
        {messages && messages.length>0 ? messages.map((msg, index) => (
          <div key={index}>
            <strong>{msg.username}:</strong> {msg.message}
          </div>
        )):("khong co gi het")}
      </div>
      <input
        type="text"
        placeholder="Nhập tin nhắn"
        value={inputMessage}
        onChange={(e) => setInputMessage(e.target.value)}
      />
      <button onClick={handleSendMessage}>Gửi</button>
    </div>
  );
};

export default ChatComponent;
