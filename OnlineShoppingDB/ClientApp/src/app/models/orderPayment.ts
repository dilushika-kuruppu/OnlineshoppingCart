import { Product } from './products';
export interface OrderPayment {
  userId: number;
  orderDate: Date;
  address: string;
  userName: string;
  total: number;
  email: string;
  OrderItemDto: Product[];
}
