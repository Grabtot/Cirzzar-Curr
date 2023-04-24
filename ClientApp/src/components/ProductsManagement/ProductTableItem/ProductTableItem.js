import React, { useState } from 'react';
import styles from './ProductTableItem.module.scss'
import { useNavigate } from 'react-router-dom';

const ProductTableItem = ({ className, product: baseProduct, onEdit, onDelete }) => {

  //const { id, name, size, type, price } = baseProduct;
  const [product, setProduct] = useState(baseProduct);
  const [editMode, setEditMode] = useState(false);
  const navigate = useNavigate();

  const handleClick = () => {
    navigate(`/menu/products/${product.id}`);
  };

  const handleEditClick = (e) => {
    e.stopPropagation();
    setEditMode(true);
  }

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setProduct(oldProduct => ({
      ...oldProduct,
      [name]: value
    }));
  }


  return (
    <tr className={className} onClick={handleClick}>
      <td className={styles["table-cell"]}>
        {editMode ? <input value={product.name} name='name' onClick={(e) => e.stopPropagation()} onChange={handleInputChange} /> : product.name}
      </td>
      <td className={styles["table-cell"]}>
        {editMode ? <input value={product.size} name='size' onClick={(e) => e.stopPropagation()} onChange={handleInputChange} /> : product.size}
      </td>
      <td className={styles["table-cell"]}>
        {editMode ? <input value={product.price} name='price' onClick={(e) => e.stopPropagation()} onChange={handleInputChange} /> : `$${product.price}`}
      </td>
      <td className={styles["table-cell"]}>{product.type}</td>
      <td className={`${styles.actions} ${styles["table-cell"]}`}>
        {editMode ?
          <button className={`${styles["action-button"]} ${styles.save}`} onClick={(e) => { e.stopPropagation(); onEdit(product); setEditMode(false); }}>
            Save
          </button>
          : <button className={`${styles["action-button"]} ${styles.edit}`} onClick={handleEditClick}>
            Edit
          </button>}
        <button className={`${styles["action-button"]} ${styles.delete}`} onClick={(e) => { e.stopPropagation(); onDelete(product.id); }}>
          Delete
        </button>
        {editMode && <button className={`${styles["action-button"]} ${styles.cancel}`} onClick={(e) => { e.stopPropagation(); setProduct(baseProduct); setEditMode(false) }}>
          Cansel
        </button>}
      </td>
    </tr>
  );
};

export default ProductTableItem;
