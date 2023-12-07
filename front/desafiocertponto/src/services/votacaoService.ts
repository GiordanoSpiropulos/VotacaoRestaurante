import { ApiResponse } from "../models/apiResponse";
import { Profissional, Restaurante } from "../types";
import { Votacao } from "../types/votacao.type";
import api from "./api";

const url_name = "/votacao";

const votacaoService = {
  getResult: () => api.get<ApiResponse<Restaurante>>(url_name),
  add: (votacao: Votacao) => api.post<ApiResponse<Votacao>>(url_name, votacao),
  getProfissionaisDidntVote: () =>
    api.get<ApiResponse<Profissional[]>>(`${url_name}/ProfissionaisDidntVote`),
};

export default votacaoService;
