import { Grid, ThemeProvider } from '@mui/material'
import theme from './theme/theme'
import React from 'react'
import RegistrarUsuario from './Components/Seguridad/RegistrarUsuario'
import Login from './Components/Seguridad/Login'
import PerfilUsuario from './Components/Seguridad/PerfilUsuario'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <Grid container>
          <Routes>
            <Route exact path="/auth/login" element={<Login />} />
            <Route
              exact
              path="/auth/registrar"
              element={<RegistrarUsuario />}
            />
            <Route exact path="/auth/perfil" element={<PerfilUsuario />} />
            <Route exact path="/" element={<PerfilUsuario />} />
          </Routes>
        </Grid>
      </Router>
    </ThemeProvider>
  )
}

export default App
