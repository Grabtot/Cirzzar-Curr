import React from 'react';
import ProductTableItem from '../ProductTableItem/ProductTableItem';
import styles from './ProductList.module.scss'
const ProductList = ({ products, loading, onEdit, onDelete }) => {
  if (loading) {
    return <p>Loading products...</p>;
  }

  return (
    <table className={styles["product-table"]}>
      <thead>
        <tr>
          <th className={styles["table-header"]}>Name</th>
          <th className={styles["table-header"]}>Size</th>
          <th className={styles["table-header"]}>Price</th>
          <th className={styles["table-header"]}>Type</th>
          <th className={styles["table-header"]}>Actions</th>
        </tr>
      </thead>
      <tbody>
        {products.length === 0 ? (
          <tr>
            <td colSpan="5">No products</td>
          </tr>
        ) : (
          products.map((product) => <ProductTableItem className={styles["table-row"]} key={product.id} product={product} onEdit={onEdit} onDelete={onDelete} />)
        )}
      </tbody>
    </table>
  );
};

export default ProductList;
