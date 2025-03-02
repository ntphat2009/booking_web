import Header from './layouts/Header'
import Footer from './layouts/Footer'
import Main from './pages/Main'
import ChatComponent from './layouts/Chat'

function App() {
  return (
    <>
   
    <div className="App">
        <Header />
        <ChatComponent/>
        <Main />
        <Footer />
      </div>
    </>
  )
}
export default App