import { ApiResponse } from "../models/apiResponse";
import { Restaurante } from "../types";
import api from "./api";

const url_name = "/restaurante";

const restauranteService = {
  getAll: () => api.get<ApiResponse<Restaurante[]>>(url_name),
  getById: (id: number) =>
    api.get<ApiResponse<Restaurante>>(`${url_name}/${id}`),
  add: (restaurante: Restaurante) =>
    api.post<ApiResponse<Restaurante>>(url_name, restaurante),
  update: (restaurante: Restaurante) =>
    api.put<ApiResponse<Restaurante>>(url_name, restaurante),
  remove: (id: number) => api.delete<ApiResponse<void>>(`${url_name}/${id}`),
};

export default restauranteService;
