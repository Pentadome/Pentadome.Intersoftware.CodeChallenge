import MonthlySaleRecord from './MonthlySaleRecord'

export default interface ProductMonthlySaleRecord{
    product: string;
    saleRecords: MonthlySaleRecord[];
}
