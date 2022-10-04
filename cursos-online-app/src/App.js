import { ThemeProvider } from '@mui/material'
import theme from './theme/theme'
import React from 'react'
// import RegistrarUsuario from './Components/Seguridad/RegistrarUsuario'
// import Login from './Components/Seguridad/Login'
import PerfilUsuario from './Components/Seguridad/PerfilUsuario'

function App() {
  return (
    <ThemeProvider theme={theme}>
      <PerfilUsuario />
    </ThemeProvider>
  )
}

export default App
