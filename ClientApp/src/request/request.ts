import axios from 'axios'

//創建實例
const API = axios.create({
  baseURL: 'http://localhost:5114/api',
  headers: {
    'Content-Type': 'application/json; charset=utf-8',
    Accept: 'application/json'
  }
})

export default API
