import { ApiResponse } from "../models/apiResponse";
import { Profissional } from "../types";
import api from "./api";

const url_name = "/Profissional";

const profissionalService = {
  getAll: () => api.get<ApiResponse<Profissional[]>>(`${url_name}`),
  getById: (id: number) =>
    api.get<ApiResponse<Profissional>>(`${url_name}/${id}`),
  add: (profissional: Profissional) =>
    api.post<ApiResponse<Profissional>>(`${url_name}`, profissional),
  update: (profissional: Profissional) =>
    api.put<ApiResponse<Profissional>>(`${url_name}`, profissional),
  remove: (id: number) => api.delete<ApiResponse<void>>(`${url_name}/${id}`),
};

export default profissionalService;
