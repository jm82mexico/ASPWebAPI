import { TextField, ThemeProvider, Button } from '@mui/material'
import theme from './theme/theme'
import React from 'react'

function App() {
  return (
    <ThemeProvider theme={theme}>
      <h1> Bienvenidos al curso de ASP.NET y React Hooks </h1>
      <TextField variant="outlined"></TextField>
      <Button variant="contained" color="primary">
        Mi botón de Material Design
      </Button>
    </ThemeProvider>
  )
}

export default App
