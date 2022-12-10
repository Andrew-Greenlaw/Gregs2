import { api } from "./AxiosService.js"

class CarsService {
  async getCars() {
    const res = await api.get('api/cars')
  }
}
export const carsService = new CarsService()