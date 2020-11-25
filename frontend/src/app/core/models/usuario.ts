import { Contacto } from './contacto';
import { Cuenta } from './cuenta';
import { Transferencia } from './transferencia';

export interface User {
    Id?: number;
    Firstname?: string;
    Password: string;
    Lastname?: string;
    Email: string;
    Dni?: number;
    Cuentas?: Cuenta[];
    Contactos?: Contacto[];
    Transferencias?: Transferencia[];
}
