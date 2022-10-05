import React, { Component, useState } from 'react'
import { Avatar, Button, Container, TextField, Typography } from '@mui/material'
import HttpsOutlinedIcon from '@mui/icons-material/HttpsOutlined'
import style from '../Tool/Style'
import { loginUsuario } from '../../actions/UsuarioAction'

const Login = () => {
  const [usuario, setUsuario] = useState({
    Email: '',
    Password: '',
  })

  const ingresarValoresMemoria = (e) => {
    const { name, value } = e.target
    setUsuario((anterior) => ({
      ...anterior,
      [name]: value,
    }))
  }

  const loginUsuarioBoton = (e) => {
    e.preventDefault()
    loginUsuario(usuario).then((res) => {
      console.log('login exitoso', res)
      window.localStorage.setItem('token_seguridad', res.data.token)
    })
  }
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
            onChange={ingresarValoresMemoria}
            value={usuario.Email}
            fullWidth
            margin="normal"
            label="Ingrese username"
          />
          <TextField
            name="Password"
            variant="outlined"
            onChange={ingresarValoresMemoria}
            value={usuario.Password}
            type="password"
            fullWidth
            margin="normal"
            label="Ingrese password"
          />
          <Button
            type="submit"
            onClick={loginUsuarioBoton}
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

export default Login
