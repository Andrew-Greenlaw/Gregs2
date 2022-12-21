import { AppState } from "../AppState.js"
import { Job } from "../models/Job.js"

class JobsService {
  getJobs() {
    const res = api.get("api/jobs")
    console.log("job data", res.data)
    AppState.jobs = res.data.map(j => new Job(j))
    console.log("[jobs]", AppState.jobs)
  }
}
export const jobsService = new JobsService()