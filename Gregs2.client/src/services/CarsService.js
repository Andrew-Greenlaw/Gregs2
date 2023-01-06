import { AppState } from "../AppState.js"
import { Car } from "../models/Car.js"
import { api } from "./AxiosService.js"

class CarsService {
  async getCars() {
    const res = await api.get('api/cars')
    console.log('[cars]', res.data)
    AppState.cars = res.data.map(c => new Car(c))
    console.log('cars?', AppState.cars)
  }
  async getCarById(id) {
    const res = await api.get(`api/cars/${id}`)
    console.log('[returned car]', res.data)
    AppState.activeCar = new Car(res.data)
    console.log(AppState.activeCar)
  }
  async createCar(data) {
    const res = await api.post('api/cars', data)
    console.log('[created car]', res.data)
    AppState.cars.push(new Car(res.data))
    console.log(AppState.cars)
  }
  async editCar(id, data) {
    const res = await api.put(`api/cars/${id}`, data)
    console.log('[edited car]', res.data)
    const updatedCar = new Car(res.data)
    const index = AppState.cars.findIndex(c => c.id = id)
    AppState.cars.splice(index, 1, updatedCar)
    // Appstate.emit('cars')         do i need to do this? and Why?
  }
  async deleteCar(id) {
    const res = await api.delete(`api/cars/${id}`)
    console.log('deleted?', res.data)
    AppState.cars.filter(c => c.id != id)
  }
} []
export const carsService = new CarsService()