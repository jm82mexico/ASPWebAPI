import { Avatar, Button, IconButton, Toolbar, Typography } from '@mui/material'
import { makeStyles } from '@mui/styles'
import React from 'react'
import FotoUsuarioTemp from '../../../logo.svg'

const useStyles = makeStyles((theme) => ({
  seccionDesktop: {
    display: 'none',
    [theme.breakpoints.up('md')]: {
      display: 'flex',
    },
  },
  seccionMobile: {
    display: 'flex',
    [theme.breakpoints.up('md')]: {
      display: 'none',
    },
  },
  grow: {
    flexGrow: 1,
  },
  avataSize: {
    width: 40,
    height: 40,
  },
  list: {
    width: 250,
  },
  listItemText: {
    fontSize: '14px',
    fontWeigth: 600,
    paddingLeft: '15px',
    color: '#212121',
  },
}))

function BarSesion() {
  const classes = useStyles()
  return (
    <Toolbar>
      <IconButton color="inherit">
        <i className="material-icons">menu</i>
      </IconButton>
      <Typography variant="h5"> Cursos Online</Typography>
      <div className={classes.grow}></div>
      <div className={classes.seccionDesktop}>
        <Button color="inherit">Salir</Button>
        <Button color="inherit">{'Nombre del usuario'}</Button>
        <Avatar src={FotoUsuarioTemp}></Avatar>
      </div>
      <div className={classes.seccionMobile}>
        <IconButton color="inherit">
          <i className="material-icons">more_vert</i>
        </IconButton>
      </div>
    </Toolbar>
  )
}

export default BarSesion
