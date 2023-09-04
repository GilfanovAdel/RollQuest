
import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';

const defaultTheme = createTheme();
export default function ConfirmCode() {
    const [code, setCode] = useState('');
    const { email } = useParams();
    const handleSubmit = () => {
        fetch('http://localhost:8080/confirmcode', {
            method: 'POST',
            mode: 'cors',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({
             code:code,
             email:email
            })
          })
          .then(response => {
            if(response.status =="200")
            {
              return response.json();
            }
            else
            {
              return response.text();
            }
          })
          .then(data => {
            
            if (data.hasOwnProperty('accessToken') && data.accessToken !== null) {
              localStorage.setItem('accessToken', data.accessToken);
              localStorage.setItem('refreshToken', data.refreshToken);
              window.location.assign('http://localhost:3000/music');
            } else {
              window.alert(data);
            }
          })
          .catch(error => {
            console.error('Ошибка при отправке данных на сервер', error);
          });
      };
    
return(
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
     
       
        <Box component="form"  noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="code"
            label="Code"
            name="code"
            autoFocus
            onChange={(event) => setCode(event.target.value)}
          />
        
         
          <Button
           onClick={handleSubmit}
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
          Send Code 
          </Button>
        
        </Box>
      </Box>
   
    </Container>
  </ThemeProvider>
)}