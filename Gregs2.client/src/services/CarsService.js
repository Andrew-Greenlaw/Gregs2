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
  async createCars() {
    const res = await api.post('api/cars')
    console.log('[created car]', res.data)
    AppState.cars.push(res.data)
    console.log(AppState.cars)
  }
} []
export const carsService = new CarsService()