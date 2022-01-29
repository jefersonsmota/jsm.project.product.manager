import { environment } from 'src/environments/environment';

export class AppConstants {
    public static USERSESSION = 'currentUserAuth';    

    public static API_RESOURCE = ((): string => {
        if (environment) {
            // dev
            return 'http://localhost:5003/';
        } else {
            // prod
            return 'https://localhost:xxx/';
        }
    })();

    public static PRODUCT_RESOURCE = 'api/produto';
    public static AUTH_RESOURCE = 'api/autenticacao';
}
