import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Home } from "./components/Home";
import ProductsManagement from './components/ProductsManagement/ProductsManagement';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },

  {
    path: "/menu/management/products",
    requireAuth: true,
    element: <ProductsManagement />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
