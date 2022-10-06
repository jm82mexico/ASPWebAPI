import { Grid, ThemeProvider } from '@mui/material'
import theme from './theme/theme'
import React, { useEffect, useState } from 'react'
import RegistrarUsuario from './Components/Seguridad/RegistrarUsuario'
import Login from './Components/Seguridad/Login'
import PerfilUsuario from './Components/Seguridad/PerfilUsuario'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import AppNavbar from './Components/navegacion/AppNavbar'
import { useStateValue } from './contexto/store'
import { obtenerUsuarioActual } from './actions/UsuarioAction'

function App() {
  const [{ sesionUsuario }, dispatch] = useStateValue()
  const [iniciaApp, setIniciaApp] = useState(false)

  useEffect(() => {
    if (!iniciaApp) {
      obtenerUsuarioActual(dispatch)
        .then((res) => {
          setIniciaApp(true)
        })
        .catch((error) => {
          setIniciaApp(true)
        })
    }
  }, [iniciaApp])
  return (
    <Router>
      <ThemeProvider theme={theme}>
        <AppNavbar />
        <Grid container>
          <Routes>
            <Route exact path="/auth/login" element={<Login />} />
            <Route
              exact
              path="/auth/registrar"
              element={<RegistrarUsuario />}
            />
            <Route exact path="/auth/perfil" element={<PerfilUsuario />} />
            <Route exact path="/" element={<Login />} />
          </Routes>
        </Grid>
      </ThemeProvider>
    </Router>
  )
}

export default App
