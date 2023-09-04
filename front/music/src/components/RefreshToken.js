export default function RefreshToken( delegate)
{
    fetch('http://localhost:8080/refreshtoken', {
        method: 'POST',
        mode: 'cors',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          refreshtoken: localStorage.getItem("refreshToken")
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
          delegate()
        } else {
          window.alert(data);
        }
      })
      .catch(error => {
        console.error('Ошибка при отправке данных на сервер', error);
      });
}