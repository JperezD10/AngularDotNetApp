import { User } from "./user";

export interface LoginApiResponse{
    token: string;
    user: User;
    message: string;
}