
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from '../src/components/Header';
import VirtualTable from './components/VirtualTable';
import SignIn from './components/SignIn';
import SignUp from './components/SignUp';
import ConfirmCode from './components/ConfirmCode';
import ConfirmEmail from './components/ConfirmEmail';


 function App() {
  return (
    <div>
      <Header></Header>
    <Router>
      <Routes>
                <Route path="SignUp" element={<SignUp></SignUp>} />
                <Route path="SignIn" element={<SignIn></SignIn>} />
                <Route path="confirmCode/:email" element={<ConfirmCode></ConfirmCode>} />
                <Route path="confirmemail" element={<ConfirmEmail></ConfirmEmail>} />
                <Route path="VirtualTable" element={<VirtualTable></VirtualTable>} />
            </Routes>
    </Router>
    </div>
  );
}

export default App;
