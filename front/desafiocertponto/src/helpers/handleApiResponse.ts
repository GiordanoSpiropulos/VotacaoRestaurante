import { AxiosResponse } from "axios";
import { ApiResponse } from "../models/apiResponse";

const handleApiResponse = <T>(
  response: AxiosResponse<ApiResponse<T>>,
  onSuccess?: (data: T | null | undefined) => void,
  onError?: (errorMessage: string) => void
) => {
  const apiResponse = response.data;
  if (apiResponse.success) {
    if (onSuccess) onSuccess(apiResponse.data);
  } else if (onError) {
    onError(apiResponse.errorMessage || "Erro desconhecido");
  }
};

export default handleApiResponse;
