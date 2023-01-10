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

}
export const jobsService = new JobsService()