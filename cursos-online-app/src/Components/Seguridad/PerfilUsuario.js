import React, { useEffect, useState } from 'react'
import { Button, Container, Grid, TextField, Typography } from '@mui/material'
import style from '../Tool/Style'
import {
  actualizarUsuario,
  obtenerUsuarioActual,
} from '../../actions/UsuarioAction'
function PerfilUsuario() {
  const [usuario, setUsuario] = useState({
    nombreCompleto: '',
    email: '',
    password: '',
    confirmarPassword: '',
    userName: '',
  })

  const ingresarValoresMemoria = (e) => {
    const { name, value } = e.target
    setUsuario((anterior) => ({
      ...anterior,
      [name]: value,
    }))
  }

  useEffect(() => {
    obtenerUsuarioActual().then((res) => {
      console.log('Esta es la data del usuario actual', res)
      setUsuario(res.data)
    })
  }, [])

  const guardarUsuario = (e) => {
    e.preventDefault()
    console.log(usuario)
    actualizarUsuario(usuario).then((res) => {
      console.log('Se actualizó el usurio', res)
      window.localStorage.setItem('token_seguridad', res.data.token)
    })
  }

  return (
    <Container component="main" maxWidth="md" justify="center">
      <div style={style.paper}>
        <Typography component="h1" variant="h5">
          Perfil de Usuario
        </Typography>
        <form style={style.form}>
          <Grid container spacing={2}>
            <Grid item xs={12} md={12}>
              <TextField
                name="nombreCompleto"
                variant="outlined"
                onChange={ingresarValoresMemoria}
                value={usuario.nombreCompleto}
                fullWidth
                label="Ingrese nombre y apellidos"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="userName"
                variant="outlined"
                onChange={ingresarValoresMemoria}
                value={usuario.userName}
                fullWidth
                label="Ingrese Username"
              />
            </Grid>

            <Grid item xs={12} md={6}>
              <TextField
                name="email"
                variant="outlined"
                onChange={ingresarValoresMemoria}
                value={usuario.email}
                fullWidth
                label="Ingrese email"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="password"
                type="password"
                onChange={ingresarValoresMemoria}
                value={usuario.password}
                variant="outlined"
                fullWidth
                label="Ingrese password"
              />
            </Grid>
            <Grid item xs={12} md={6}>
              <TextField
                name="confirmarPassword"
                value={usuario.confirmarPassword}
                type="password"
                onChange={ingresarValoresMemoria}
                variant="outlined"
                fullWidth
                label="confirme password"
              />
            </Grid>
          </Grid>
          <Grid container justify="center">
            <Grid item xs={12} md={12}>
              <Button
                type="submit"
                fullWidth
                onClick={guardarUsuario}
                variant="contained"
                size="large"
                color="primary"
                style={style.submit}
              >
                Guardar Datos
              </Button>
            </Grid>
          </Grid>
        </form>
      </div>
    </Container>
  )
}

export default PerfilUsuario
