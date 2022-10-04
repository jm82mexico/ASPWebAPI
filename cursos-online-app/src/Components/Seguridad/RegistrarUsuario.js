import { Button, Container, Grid, TextField, Typography } from '@mui/material'
import React, { useState } from 'react'
import { registrarUsuario } from '../../actions/UsuarioAction'
import style from '../Tool/Style'
const RegistrarUsuario = () => {
  const [usuario, setUsuario] = useState({
    NombreCompleto: '',
    Email: '',
    Password: '',
    ConfirmarPassword: '',
    Username: '',
  })

  const ingresarValoresMemoria = (e) => {
    const { name, value } = e.target
    setUsuario((anterior) => ({
      ...anterior,
      [name]: value,
    }))
  }

  const registrarUsuarioBoton = (e) => {
    e.preventDefault()
    console.log(usuario)
    registrarUsuario(usuario).then((res) => {
      console.log('Se registro correctamente el usuario', res)
      window.localStorage.setItem('token_seguridad', res.data.token)
    })
  }

  return (
    <Container component="main" maxWidth="md" justify="center">
      <div style={style.paper}>
        <Typography component="h1" variant="h5">
          Registro de usuario
        </Typography>
        <form style={style.form}>
          <Grid container spacing={2}>
            <Grid item xs={12} md={12}>
              <TextField
                name="NombreCompleto"
                variant="outlined"
                value={usuario.NombreCompleto}
                onChange={ingresarValoresMemoria}
                fullWidth
                label="Ingrese Nombre y apellidos"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="Email"
                variant="outlined"
                value={usuario.Email}
                onChange={ingresarValoresMemoria}
                fullWidth
                label="Ingrese su email"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="Username"
                variant="outlined"
                value={usuario.Username}
                onChange={ingresarValoresMemoria}
                fullWidth
                label="Ingrese su Username"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="Password"
                variant="outlined"
                value={usuario.Password}
                onChange={ingresarValoresMemoria}
                type="password"
                fullWidth
                label="Ingrese su password"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="ConfirmarPassword"
                variant="outlined"
                value={usuario.ConfirmarPassword}
                onChange={ingresarValoresMemoria}
                type="password"
                fullWidth
                label="Confirme su password"
              />
            </Grid>
          </Grid>
          <Grid container justify="center">
            <Grid item xs={12} md={12}>
              <Button
                type="submit"
                fullWidth
                variant="contained"
                onClick={registrarUsuarioBoton}
                color="primary"
                size="large"
                style={style.submit}
              >
                Enviar
              </Button>
            </Grid>
          </Grid>
        </form>
      </div>
    </Container>
  )
}

export default RegistrarUsuario
