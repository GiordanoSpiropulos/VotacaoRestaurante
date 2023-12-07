export class ApiResponse<T> {
  success: boolean;
  data: T | null | undefined;
  errorMessage: string;

  constructor(
    success: boolean,
    data: T | null | undefined,
    errorMessage: string = ""
  ) {
    this.success = success;
    this.data = data;
    this.errorMessage = errorMessage;
  }

  static successResponse<T>(data: T): ApiResponse<T> {
    return new ApiResponse<T>(true, data);
  }

  static errorResponse<T>(errorMessage: string): ApiResponse<T> {
    return new ApiResponse<T>(false, null, errorMessage);
  }
}
