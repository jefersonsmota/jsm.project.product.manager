import { environment } from 'src/environments/environment';

export class AppConstants {
    public static USERSESSION = 'currentUserAuth';    

    public static API_RESOURCE = ((): string => {
        if (environment.production) {
            // dev
            return environment.productApi;
        } else {
            // prod
            return environment.productApi;
        }
    })();

    public static PRODUCT_RESOURCE = 'api/produto';
    public static AUTH_RESOURCE = 'api/autenticacao';
}
