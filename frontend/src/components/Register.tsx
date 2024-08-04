import React, { useState } from 'react';
   import axios from 'axios';

   const Register: React.FC = () => {
     const [username, setUsername] = useState('');
     const [password, setPassword] = useState('');
     const [email, setEmail] = useState('');

     const handleRegister = async () => {
       try {
         const response = await axios.post('/api/users/register', { username, password, email });
         console.log('Registration successful:', response.data);
       } catch (error) {
         console.error('Registration failed:', error);
       }
     };

     return (
       <div>
         <h2>Register</h2>
         <input
           type="text"
           placeholder="Username"
           value={username}
           onChange={(e) => setUsername(e.target.value)}
         />
         <input
           type="password"
           placeholder="Password"
           value={password}
           onChange={(e) => setPassword(e.target.value)}
         />
         <input
           type="email"
           placeholder="Email"
           value={email}
           onChange={(e) => setEmail(e.target.value)}
         />
         <button onClick={handleRegister}>Register</button>
       </div>
     );
   };

   export default Register;