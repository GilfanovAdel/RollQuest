
import React, { useState } from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';



const defaultTheme = createTheme();

export default function SignUp() {
    const [email, setEmail] = useState('');
    const [name, setName] = useState('');
  const handleSubmit = () => {
    fetch('http://localhost:8080/registration', {
        method: 'POST',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          email: email,
          name:name
        })
      })
      .then(response => {
       
       
         if(response.status == "200")
         {
          window.alert("проверьте почту")
          return "1";
         }
       else
         {
          var data =   response.text()
          return data;
         }
      })
      .then(data => 
        {
          if(data == "1")
          {
            return;
          }
          window.alert(data);
        })
      .catch(error => {
      
        console.error('Ошибка при отправке данных на сервер', error);
      });
  };

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign up
          </Typography>
          <Box component="form"  noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="name"
              label="Name"
              name="name"
              autoComplete="name"
              autoFocus
              onChange={(event) => setName(event.target.value)}
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="email"
              label="Email"
              id="email"
              autoComplete="email" 
               onChange={(event) => setEmail(event.target.value)}
            />
           
            <Button
             onClick={handleSubmit}
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
           
          </Box>
        </Box>
     
      </Container>
    </ThemeProvider>
  );
}