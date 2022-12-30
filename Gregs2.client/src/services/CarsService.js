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
  async createCar(data) {
    const res = await api.post('api/cars', data)
    console.log('[created car]', res.data)
    AppState.cars.push(new Car(res.data))
    console.log(AppState.cars)
  }
} []
export const carsService = new CarsService()