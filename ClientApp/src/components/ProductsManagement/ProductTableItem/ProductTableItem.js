import React from 'react';
import styles from './ProductTableItem.module.scss'

const ProductTableItem = ({ className, product, onEdit, onDelete }) => {

  const { id, name, size, type, price } = product;

  return (
    <tr className={className}>
      <td className={styles["table-cell"]}>{name}</td>
      <td className={styles["table-cell"]}>{size}</td>
      <td className={styles["table-cell"]}>${price}</td>
      <td className={styles["table-cell"]}>{type}</td>
      <td className={`${styles.actions} ${styles["table-cell"]}`}>
        <button className={`${styles["action-button"]} ${styles.edit}`} onClick={() => onEdit(product)}>
          Edit
        </button>
        <button className={`${styles["action-button"]} ${styles.delete}`} onClick={() => onDelete(id)}>
          Delete
        </button>
      </td>
    </tr>
  );
};

export default ProductTableItem;
