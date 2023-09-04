

import React, { useEffect,useState } from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardHeader from '@mui/material/CardHeader';
import CssBaseline from '@mui/material/CssBaseline';
import Grid from '@mui/material/Grid';
import StarIcon from '@mui/icons-material/StarBorder';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Link from '@mui/material/Link';
import GlobalStyles from '@mui/material/GlobalStyles';
import Container from '@mui/material/Container';
import { Menu } from '@mui/material';
import MenuItem from '@mui/material/MenuItem';

function Header()
{
  const Logout = () => {
 
    localStorage.setItem('accessToken',null);
    localStorage.setItem('refreshToken',null);
    setIsLoggedIn(false);
  }

  const renderButton = () => {
    if (isLoggedIn) {
      return   (<div> <Button
        
      id="basic-button"
      aria-controls={open ? 'basic-menu' : undefined}
      aria-haspopup="true"
      aria-expanded={open ? 'true' : undefined}
      onClick={handleClick}
      >
        Account
      </Button>
      <Menu
      
      id="basic-menu"
      anchorEl={anchorEl}
      open={open}
      onClose={handleClose}
      MenuListProps={{
        'aria-labelledby': 'basic-button',
      
        }}
      >
        <MenuItem onClick={() => window.location.assign("http://localhost:3000/subscription")} >Subscription </MenuItem>
        <MenuItem >VirtualTable onClick={() => window.location.assign("http://localhost:3000/virtualtable")}</MenuItem>
        <MenuItem  onClick={Logout}>Logout</MenuItem>
      </Menu></div>);
    } else {
      return    <Button href="../SignIn"  variant="outlined" sx={{ my: 1, mx: 1.5 }}>
      Login
    </Button>
    }
  }
  const [anchorEl, setAnchorEl] = React.useState(null);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const handleClick = (e) => {
    setAnchorEl(e.currentTarget);
  };
  const open = Boolean(anchorEl);
  const handleClose = () => {
    setAnchorEl(null);
  };
  useEffect(() => {
    console.log(localStorage.getItem('accessToken'))
    const accessToken = localStorage.getItem('accessToken');
    setIsLoggedIn(accessToken !== 'null' ? true : false);
  }, []);
    return <div>
         <React.Fragment>
      <GlobalStyles styles={{ ul: { margin: 0, padding: 0, listStyle: 'none' } }} />
      <CssBaseline />
      <AppBar
        position="static"
        color="default"
        elevation={0}
        sx={{ borderBottom: (theme) => `1px solid ${theme.palette.divider}` }}
      >
        <Toolbar sx={{ flexWrap: 'wrap' }}>
          <Typography variant="h6" color="inherit" noWrap sx={{ flexGrow: 1 }}>
           Adel Music
          </Typography>
          <nav>
            <Link
              variant="button"
              color="text.primary"
              href="../VirtualTable"
              sx={{ my: 1, mx: 1.5 }}
            >
              MapConstructor
            </Link>
          </nav>
     
     
       {renderButton()}
          
        </Toolbar>
        
      </AppBar>
   {}
      </React.Fragment>
    </div>  
}

export default Header