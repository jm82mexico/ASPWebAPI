import React, { Component } from 'react'
import { Avatar, Button, Container, TextField, Typography } from '@mui/material'
import HttpsOutlinedIcon from '@mui/icons-material/HttpsOutlined'
import style from '../Tool/Style'

export class Login extends Component {
  render() {
    return (
      <Container maxWidth="xs">
        <div style={style.paper}>
          <Avatar style={style.avatar}>
            <HttpsOutlinedIcon style={style.ic} />
          </Avatar>
          <Typography component="h1" variant="h5">
            Login de usuario
          </Typography>
          <form style={style.form}>
            <TextField
              name="Email"
              variant="outlined"
              fullWidth
              margin="normal"
              label="Ingrese username"
            />
            <TextField
              name="Password"
              variant="outlined"
              type="password"
              fullWidth
              margin="normal"
              label="Ingrese password"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              style={style.submit}
            >
              {' '}
              Enviar
            </Button>
          </form>
        </div>
      </Container>
    )
  }
}

export default Login
