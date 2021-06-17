import { environment } from 'src/environments/environment';

export class AppConstants {
    public static USERSESSION = 'currentUserAuth';    

    public static API_RESOURCE = ((): string => {
        if (environment) {
            // dev
            return 'http://localhost:3949/';
        } else {
            // prod
            return 'http://localhost:xxx/';
        }
    })();

    public static PRODUCT_RESOURCE = 'api/produto';
    public static AUTH_RESOURCE = 'api/autenticacao';
}
