import React from 'react';
import styles from './ProductTableItem.module.scss'
import { useNavigate } from 'react-router-dom';

const ProductTableItem = ({ className, product, onEdit, onDelete }) => {

  const { id, name, size, type, price } = product;
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/menu/products/${id}`);
  };

  return (
    <tr className={className} onClick={handleClick}>
      <td className={styles["table-cell"]}>{name}</td>
      <td className={styles["table-cell"]}>{size}</td>
      <td className={styles["table-cell"]}>${price}</td>
      <td className={styles["table-cell"]}>{type}</td>
      <td className={`${styles.actions} ${styles["table-cell"]}`}>
        <button className={`${styles["action-button"]} ${styles.edit}`} onClick={(e) => { e.stopPropagation(); onEdit(product); }}>
          Edit
        </button>
        <button className={`${styles["action-button"]} ${styles.delete}`} onClick={(e) => { e.stopPropagation(); onDelete(id); }}>
          Delete
        </button>
      </td>
    </tr>
  );
};

export default ProductTableItem;
