import React from 'react'
import Index from './home/Index';
import { Route, BrowserRouter, Routes, Router } from "react-router-dom";
import SignIn from './authentication/SignIn';
import SignUp from './authentication/SignUp';
import VerifyEmailSuccess from './authentication/VerifyEmailSuccess';
import ListProperty from './searchResult/ListProperty';
import Property from './searchResult/Property';
const Main: React.FC = () => {
  return (
    <BrowserRouter>
      <main>
        <Routes>
          <Route path="/" element={<Index />} />
          <Route path="/search-result/:cityUrl" element={<ListProperty />} />
          {/* <Route path="/search-result/:cityUrl/:propertyUrl" element={<Property />} /> */}
          <Route path="/search-result/city/des" element={<Property />} />

          <Route path="/sign-in" element={<SignIn />} />
          <Route path="/sign-up" element={<SignUp />} />
          <Route path="/isverify" element={<VerifyEmailSuccess />} />
        </Routes>
      </main>
    </BrowserRouter>
  );
};
export default Main;