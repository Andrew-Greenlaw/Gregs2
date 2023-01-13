import { AppState } from "../AppState.js"
import { Job } from "../models/Job.js"
import { api } from "./AxiosService.js"

class JobsService {
  async getJobs() {
    const res = await api.get("api/jobs")
    console.log("job data", res.data)
    AppState.jobs = res.data.map(j => new Job(j))
    console.log("[jobs]", AppState.jobs)
  }
  async getJobById(id) {
    const res = await api.get(`api/jobs/${id}`)
    console.log('job', res.data)
    AppState.activeJob = new Job(res.data)
    console.log('proxy obj job', AppState.activeJob)
  }
  async createJob(data) {
    const res = await api.post(`api/jobs`, data)
    console.log(res.data)
    AppState.jobs.push(new Job(res.data))
  }
  async editJob(id, data) {
    const res = await api.put(`api/jobs/${id}`, data)
    console.log('[Updated Job]', res.data)
    const updatedJob = new Job(res.data)
    const index = AppState.jobs.findIndex(j => j.id = id)
    AppState.jobs.splice(index, 1, updatedJob)
    // Appstate.emit('jobs')
  }
  async deleteJob(id) {
    const res = await api.delete(`api/jobs/${id}`)
    console.log('deleted?', res.data)
    AppState.jobs.filter(j => j.id != id)
    console.log(AppState.jobs)
  }

}
export const jobsService = new JobsService()