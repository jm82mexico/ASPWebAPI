import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:5227/api'

const requestGenerico = {
  get: (url) => axios.get(url),
  post: (url, body) => axios.post(url, body),
  put: (url, body) => axios.get(url, body),
  delete: (url) => axios.get(url),
}

export default requestGenerico
