import HttpCliente from '../services/HttpCliente'

export const registrarUsuario = (usuario) => {
  return new Promise((resolve, reject) => {
    HttpCliente.post('/usuario/registrar', usuario).then((response) => {
      resolve(response)
    })
  })
}
