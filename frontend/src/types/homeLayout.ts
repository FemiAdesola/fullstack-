import { ReactNode } from "react";

export  type HomeLayout= {
  children: ReactNode;
  title?: string;
  description?: string;
};

export type Props = {
  webHeading?: string;
  comment?: string;
  keywords?: string;
};