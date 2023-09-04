import React from 'react';
import { useLocation } from 'react-router-dom';

function ConfirmEmail() {
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);
  const code = searchParams.get('code');
  const email = searchParams.get('email');

  fetch('http://localhost:8080/confirmemail?code=' + code + '&email=' + email, {
            method: 'GET',
            mode: 'cors',
            headers: {
              'Content-Type': 'application/json'
            },

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
 
  


export default ConfirmEmail;
