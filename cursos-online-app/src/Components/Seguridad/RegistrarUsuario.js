import { Button, Container, Grid, TextField, Typography } from '@mui/material'
import React, { Component } from 'react'
import style from '../Tool/Style'
export class RegistrarUsuario extends Component {
  render() {
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
                  fullWidth
                  label="Ingrese Nombre y apellidos"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="Email"
                  variant="outlined"
                  fullWidth
                  label="Ingrese su email"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="Username"
                  variant="outlined"
                  fullWidth
                  label="Ingrese su Username"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="Password"
                  variant="outlined"
                  type="password"
                  fullWidth
                  label="Ingrese su password"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="ConfirmarPassword"
                  variant="outlined"
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
}

export default RegistrarUsuario
