import { AppState } from "../AppState.js"
import { House } from "../models/House.js"
import { api } from "./AxiosService.js"

class HousesService {
  async getHouses() {
    const res = await api.get('api/houses')
    console.log('[houses]', res.data)
    AppState.houses = res.data.map(h => new House(h))
  }
  async getHouseById(id) {
    const res = await api.get(`api/houses/${id}`)
    console.log('house?', res.data)
    AppState.activeHouse = new House(res.data)
  }
  async createHouse(data) {
    const res = await api.post('api/houses', data)
    console.log(res.data)
    AppState.houses.push(new House(res.data))
  }
  async editHouse(id, data) {
    const res = await api.put(`api/houses/${id}`, data)
    console.log(res.data)
    const updatedHouse = new House(res.data)
    const index = AppState.houses.findIndex(h => h.id = id)
    AppState.houses.splice(index, 1, updatedHouse)
    //Appsstate.emit('houses')
  }
  async deleteHouse(id) {
    const res = await api.delete(`api/houses/${id}`)
    AppState.houses.filter(h => h.id != id)
    console.log('new houses array', AppState.houses)
  }
}
export const housesService = new HousesService()