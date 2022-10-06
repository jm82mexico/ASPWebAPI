import HttpCliente from '../services/HttpCliente'

export const registrarUsuario = (usuario) => {
  return new Promise((resolve, reject) => {
    HttpCliente.post('/usuario/registrar', usuario).then((response) => {
      resolve(response)
    })
  })
}

export const obtenerUsuarioActual = (dispatch) => {
  return new Promise((resolve, reject) => {
    HttpCliente.get('/usuario').then((res) => {
      dispatch({
        type: 'INICIAR_SESION',
        sesion: res.data,
        autenticado: true,
      })
      resolve(res)
    })
  })
}

export const actualizarUsuario = (usuario) => {
  return new Promise((resolve, reject) => {
    HttpCliente.put('/usuario', usuario).then((res) => {
      resolve(res)
    })
  })
}

export const loginUsuario = (usuario) => {
  return new Promise((resolve, reject) => {
    HttpCliente.post('/usuario/login', usuario).then((res) => {
      resolve(res)
    })
  })
}
