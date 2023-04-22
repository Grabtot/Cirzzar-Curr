import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Home } from "./components/Home";

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
